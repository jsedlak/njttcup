import React from 'react';
import { Header, Menu } from '../parts/PageParts';

import { Fabric } from '../Fabric'
import './LeaderboardsPage.css';

const fabric = new Fabric();

export class LeaderboardsPage extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            leaderboard: null,
            years: [2018]
        };
    }

    componentDidMount() {
        // fabric.getLeaderboard(2018)
        //     .then(leaderboard => {
        //         this.setState({ leaderboard: leaderboard })
        //     });

        fabric.getYears()
            .then(years => { this.setState({ years: years }); });
    }

    handleYearChanged = (ev, value) => {
        if(ev.target.value === "") {
            return;
        }

        this.setState({selectedYear: ev.target.value});

        fabric.getLeaderboard(ev.target.value)
            .then(leaderboard => {
                this.setState({ leaderboard: leaderboard })
            });
    }

    render() {
        return (
            <div>
                <Header>
                    <Menu />
                </Header>

                <div className="document document-data" style={{overflowX: 'scroll'}}>
                    <div className="message message-warning">
                        <strong>Beta Feature</strong> - the data for this feature for years prior to 2019 have not been fully vetted and should be considered unofficial.
                    </div>
                    <div>
                        <label>Leaderboard Year </label>
                        <select 
                            style={{padding: '10px 15px', borderRadius: '30px'}}
                            value={this.state.selectedYear}
                            onChange={this.handleYearChanged}>
                            <option value="">Select a year to begin...</option>
                            {this.state.years.map((year) =>
                                <option key={year} value={year}>{year}</option>
                            )}
                        </select>
                    </div>
                    {this.state.leaderboard && (
                        <div>
                            {this.state.leaderboard.categories.map((category, categoryIndex) =>
                                <div key={categoryIndex} className="panel panel-collapsible">
                                    <h2>{category.name}</h2>
                                    <table className="table table-data table-leaderboard">
                                        <thead>
                                            <tr>
                                                <th>Name</th>
                                                <th>Team</th>
                                                {category.riders[0].points.map((points, pointsIndex) => 
                                                    <th key={pointsIndex}>{pointsIndex+1}</th>
                                                )}
                                                <th>Subtotal</th>
                                                <th>Total</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        {category.riders.filter(rider => rider.total > 0).map((rider, riderIndex) =>
                                            <tr key={riderIndex}>
                                                <td>{rider.name}</td>
                                                <td>{rider.team}</td>
                                                {rider.points.map((points, pointsIndex) =>
                                                    <td key={pointsIndex}>{points}</td>
                                                )}
                                                <td className="table-cell-total">{rider.rawTotal}</td>
                                                <td className="table-cell-total">{rider.total}</td>
                                            </tr>
                                        )}
                                        </tbody>
                                    </table>
                                </div>
                            )}
                        </div>
                    )}
                </div>
            </div>
        )
    }
}
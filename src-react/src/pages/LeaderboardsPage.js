import React from 'react';
import { Header, Menu } from '../parts/PageParts';

import { Fabric } from '../Fabric'

const fabric = new Fabric();

export class LeaderboardsPage extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            leaderboard: null
        };
    }

    componentDidMount() {
        fabric.getLeaderboard(2018)
            .then(leaderboard => {
                this.setState({ leaderboard: leaderboard })
            })
    }

    render() {
        return (
            <div>
                <Header>
                    <Menu />
                </Header>

                <div className="document document-data" style={{overflowX: 'scroll'}}>
                    {this.state.leaderboard && (
                        <div>
                            {this.state.leaderboard.categories.map((category, categoryIndex) =>
                                <div key={categoryIndex}>
                                    <h2>{category.name}</h2>
                                    <table class="table table-data">
                                        {category.riders.map((rider, riderIndex) =>
                                            <tr key={riderIndex}>
                                                <td>{rider.name}</td>
                                                <td>{rider.team}</td>
                                                {rider.points.map((points, pointsIndex) =>
                                                    <td key={pointsIndex}>{points}</td>
                                                )}
                                            </tr>
                                        )}
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
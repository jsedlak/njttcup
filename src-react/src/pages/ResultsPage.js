import React from 'react';
import { Fabric } from '../Fabric'
import { Header, Menu } from '../parts/PageParts';

const fabric = new Fabric();

export class ResultsPage extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            years: [],
            events: []
        };
    }

    componentDidMount() {
        fabric.getYears().then(years => { this.setState({ years: years }); });
    }

    handleYearChanged = (ev) => {
        if(ev.target.value === "") {
            return;
        }

        this.setState({selectedYear: ev.target.value});

        fabric.getEvents(ev.target.value)
            .then(events => {
                this.setState({ events: events });
            });
    }

    handleEventChanged = (ev) => {
        if(ev.target.value === "") {
            return;
        }

        const val = ev.target.value;
        const event = this.state.events.filter(ev => ev.name === val)[0];
        this.setState({
            selectedEvent: ev.target.value,
            event: event
        });

        console.log(event);
    }

    render() {
        return (
            <div>
                <Header />
                <div style={{ display: 'flex', justifyContent: 'center' }}>
                    <Menu />
                </div>
                <div className="document document-data">
                    <div>
                        <label>Select a year and an event to see the results...</label>
                        <select 
                            className="input-field"
                            value={this.state.selectedYear}
                            onChange={this.handleYearChanged}>
                            <option value="">Select a year to begin...</option>
                            {this.state.years.map((year) =>
                                <option key={year} value={year}>{year}</option>
                            )}
                        </select>

                        <select
                            className="input-field"
                            value={this.state.selectedEvent}
                            onChange={this.handleEventChanged}>
                            <option value="">Select an event to continue...</option>
                            {this.state.events.map((event, eventIndex) =>
                                <option key={eventIndex} value={event.name}>{event.name}</option>
                            )}
                        </select>

                    </div>

                    {this.state.event && 
                    <div>
                        <h2>{this.state.event.name}</h2>

                        {this.state.event.categories.map((cat, catIndex) => 
                        <div className="panel panel-collapsible" key={catIndex}>
                            <h3>{cat.name}</h3>
                            <table className="table table-data">
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th>Name</th>
                                        <th>Team</th>
                                        <th>Points</th>
                                        <th>Time</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {cat.results.map((result, resultIndex) => 
                                    <tr key={resultIndex}>
                                        <td style={{textAlign:'center', width: '25px'}}>{result.place}</td>
                                        <td>{result.name}</td>
                                        <td>{result.team}</td>
                                        <td>{result.points}</td>
                                        <td>{result.time}</td>
                                    </tr>
                                    )}
                                </tbody>
                            </table>
                        </div>
                        )}
                    </div>}
                </div>
            </div>
        )
    }
}
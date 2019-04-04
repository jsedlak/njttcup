import React from 'react';
import { Fabric } from '../Fabric'
import { Header, Menu } from '../parts/PageParts';
import 'whatwg-fetch'; 
import './Results.css';

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
        const getEventsClassName = () => {
            var cls = "input-field";
            if(this.state.events == null || this.state.events.length === 0) {
                cls += " disabled";
            }
            return cls;
        }

        const getYearsClassName = () => {
            var cls = "input-field";
            if(this.state.years == null || this.state.years.length === 0) {
                cls += " disabled";
            }
            return cls;
        }

        return (
            <div>
                <Header>
                    <Menu />
                </Header>
                <div className="document document-data">
                    <div className="results-header">
                        <div className="results-filters">
                            <select 
                                className={getYearsClassName()}
                                value={this.state.selectedYear}
                                onChange={this.handleYearChanged}>
                                <option value="">Select a year to begin...</option>
                                {this.state.years.map((year) =>
                                    <option key={year} value={year}>{year}</option>
                                )}
                            </select>

                            <select
                                className={getEventsClassName()}
                                value={this.state.selectedEvent}
                                onChange={this.handleEventChanged}>
                                <option value="">Select an event to continue...</option>
                                {this.state.events.map((event, eventIndex) =>
                                    <option key={eventIndex} value={event.name}>{event.name}</option>
                                )}
                            </select>
                        </div>
                        

                    </div>

                    {this.state.event && 
                    <div>
                        <h2>{this.state.event.name}</h2>

                        {this.state.event.categories.map((cat, catIndex) => 
                        <div className={`panel panel-collapsible panel-results ${this.state['active' + catIndex] ? '' : 'active'}`} key={catIndex}>
                            <h2 onClick={() => {
                                        var isActive = this.state['active' + catIndex];
                                        var newState = {};
                                        newState['active' + catIndex] = !isActive;
                                        this.setState(newState);
                                    }} className="panel-title">{cat.name}</h2>
                            <table className="table table-data">
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th>Name</th>
                                        <th className="hide-phone">Team</th>
                                        <th className="hide-phone">Points</th>
                                        <th>Time</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {cat.results.map((result, resultIndex) => 
                                    <tr key={resultIndex}>
                                        <td style={{textAlign:'center', width: '25px'}}>{result.place}</td>
                                        <td>{result.name}</td>
                                        <td className="hide-phone">{result.team}</td>
                                        <td className="hide-phone">{result.points}</td>
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
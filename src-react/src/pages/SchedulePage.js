import React from 'react';
import { Header, Menu } from '../parts/PageParts';
import {Courses} from '../data/Courses';
import {Schedules} from '../data/Schedules';
import './SchedulePage.css';

const THE_YEAR = new Date().getFullYear();

export class SchedulePage extends React.Component {
    constructor(props){
        super(props);

        this.state = {
            schedule: []
        };
    }

    componentDidMount() {
        var getCourse = function(id) {
            return Courses.filter(c => { return c.id === id; })[0];
        }

        var currentSchedule = Schedules.filter(s => { return s.year === THE_YEAR })[0];

        this.setState({
            schedule: currentSchedule.schedule.map(scheduleItem => {
                scheduleItem.course = getCourse(scheduleItem.courseId);
                return scheduleItem;
            })
        });
    }

    render() {
        return (
            <div>
                <Header>
                    <Menu />
                </Header>

                <div className="document">
                <h1>Schedule</h1>
                <p>Below is the schedule for <strong>{THE_YEAR}</strong>. For updates &amp; cancellations, please follow us on the <a href="https://www.facebook.com/groups/454823674652201/">NJ Time Trial Cup Cycling Series</a> Facebook group.</p>

                <table className="table table-data table-schedule">
                    <thead>
                        <tr>
                            <th>No.</th>
                            <th>Date</th>
                            <th>Course</th>
                            {/* <th className="hide-phone">Subcourse</th> */}
                            <th className="hide-phone">Distance</th>
                            <th className="hide-phone">Type</th>
                            <th className="hide-phone">Registration</th>
                            <th className="hide-phone">Results</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.schedule.map((event, eventIndex) => {
                            return (
                                <tr key={event.date} data-status={event.status}>
                                    <td>{eventIndex+1}</td>
                                    <td>{event.date}</td>
                                    <td>
                                        {event.status && <span className={`tag tag-status tag-status-${event.status}`}>{event.status}</span>}
                                        <a href={`/courses/${event.courseId}`}>{event.course.name}<br/>{event.promoter}</a>
                                    </td>
                                    {/* <td className="hide-phone"></td> */}
                                    <td className="hide-phone">{event.course.distance}<br/><small>(+{event.course.elevation})</small></td>
                                    <td className="hide-phone">{event.course.type}</td>
                                    <td>
                                        {event.registration.length>0 &&
                                            <a className="btn btn-primary" href={event.registration}>Register</a>
                                        }
                                    </td>
                                    <td className="hide-phone">
                                        {event.results.length>0 &&
                                            <a className="btn" href={event.results}>Link</a>
                                        }
                                    </td>
                                </tr>
                            )
                        })}
                    </tbody>
                </table>


                </div>
            </div>
        )
    }
}
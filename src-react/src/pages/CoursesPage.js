import React from 'react';
import { Header, Menu } from '../parts/PageParts';
import { Courses } from '../data/Courses'

export class CoursesPage extends React.Component {

    render() {
        return (
            <div>
                <Header>
                    <Menu />
                </Header>
                <div className="document">
                    <div className="row">
                    {Courses.map((course, courseIndex) => { 
                        var defaultCourse = course.subcourses.filter(sc => { return sc.isDefault; })[0];

                        return (
                        <div key={course.id} className="card-wrapper" style={{marginBottom:'30px'}}>
                            <div className="card" style={{height:'100%'}}>
                                <div className="card-title">{course.name}</div>
                                <img 
                                    src={`https://ridewithgps.com/routes/full/${defaultCourse.rideWithGps}.png`} 
                                    className="card-img-top"
                                    alt={course.name}
                                />
                                <div className="card-body">
                                    {/* <h5 className="card-title">{course.name}</h5> */}
                                    <h6 className="card-subtitle mb-2 text-muted">{course.type}</h6>
                                    <p className="text-muted text-small"><small>
                                        Distance: {course.distance}<br/>
                                        Gain: {course.elevation}
                                    </small></p>
                                    <p>{course.description}</p>
                                </div>
                                <div className="card-footer">
                                    <a className="btn btn-primary w-100" href={`/courses/${course.id}`}>More Information</a>
                                </div>
                            </div>
                        </div>
                        )
                    })}
                    </div>

                </div>
            </div>
        )
    }
}
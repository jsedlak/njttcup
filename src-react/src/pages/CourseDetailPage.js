import React from 'react';
import { Header, Menu } from '../parts/PageParts';
import { Courses } from '../data/Courses'
import YouTube from 'react-youtube';

export class CourseDetailPage extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            course: Courses.filter(c => { return c.id === props.match.params.courseId})[0]
        };
    }

    renderNotes = (notes) => {
        if(notes === null || notes.length === 0){
            return (<span></span>);
        }

        return (
            <div className="alert alert-danger" role="alert">
                <h5>Important Info</h5>
                <p dangerouslySetInnerHTML={{__html: notes }}></p>
            </div>
        )
    }


    render() {
        var defaultCourse = this.state.course.subcourses.filter(sc => { return sc.isDefault; })[0];
        return (
            <div>
                <Header />
                <div style={{ display: 'flex', justifyContent: 'center' }}>
                    <Menu />
                </div>
                <div className="document">
                <div className="row">
                    <div className="col-lg">
                        <h2>{this.state.course.name}</h2>
                    </div>
                </div>

                {this.renderNotes(this.state.course.notes)}

                <h4>Stats</h4>
                <table className="table table-data">
                    <tr>
                        <td>Type</td>
                        <td>{this.state.course.type}</td>
                    </tr>
                    <tr>
                        <td>Distance</td>
                        <td>{this.state.course.distance}</td>
                    </tr>
                    <tr>
                        <td>Elevation Gain</td>
                        <td>{this.state.course.elevation}</td>
                    </tr>
                    <tr>
                        <td>Promoter<sup>1</sup></td>
                        <td>{this.state.course.promoter}</td>
                    </tr>
                </table>

                <h4>General Information</h4>
                <p dangerouslySetInnerHTML={{__html: this.state.course.fullDescription}}></p>

                <h4>Parking</h4>
                <p dangerouslySetInnerHTML={{__html: this.state.course.parkingInfo}}></p>

                <h4>Current Course</h4>
                <iframe 
                title={defaultCourse.name}
                src={`https://rwgps-embeds.com/embeds?type=route&id=${defaultCourse.rideWithGps}&sampleGraph=true`} 
                style={{width:'1px',minWidth:'100%',height:'600px',border:'none'}} 
                scrolling='no'></iframe>

                {defaultCourse.youtube.length > 0 &&
                    <section id="course-video">
                        <h4>Video</h4>
                        <YouTube videoId={defaultCourse.youtube} />
                    </section>
                }
                
                <p><small><strong><sup>1</sup> Promoter</strong> is subject to change for each event. Listed promoter is default/typical for the event but may not be responsible for day-of operation, scoring or results.</small></p>


                </div>
            </div>
        )
    }
}
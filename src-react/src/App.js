import React, { Component } from 'react';
import './App.css';
import triangle from './triangle.svg';
import { BrowserRouter, Route } from 'react-router-dom';

import {LandingPage} from './pages/LandingPage'
import {RulesPage} from './pages/RulesPage'
import {LeaderboardsPage} from './pages/LeaderboardsPage'
import { ResultsPage } from './pages/ResultsPage';
import { CoursesPage } from './pages/CoursesPage';
import { CourseDetailPage } from './pages/CourseDetailPage';
import { SchedulePage } from './pages/SchedulePage';

class App extends Component {
    render() {
        return (
            <BrowserRouter>
            <div className="app">
                <img alt="geometric background" src={triangle} className="triangle" />

                <div className="page">
                        <Route exact path="/" component={LandingPage} />
                        <Route path="/rules" component={RulesPage} />
                        <Route path="/results" component={ResultsPage} />
                        <Route path="/leaderboards" component={LeaderboardsPage} />
                        <Route path="/courses/:courseId" component={CourseDetailPage} />
                        <Route path="/courses" component={CoursesPage} />
                        <Route path="/schedule" component={SchedulePage} />
                </div>
            </div>
            </BrowserRouter>
        );
    }
}

export default App;

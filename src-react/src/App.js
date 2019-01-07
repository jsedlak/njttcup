import React, { Component } from 'react';
import './App.css';
import triangle from './triangle.svg';
import { BrowserRouter, Route } from 'react-router-dom';

import {LandingPage} from './pages/LandingPage'
import {RulesPage} from './pages/RulesPage'
import {LeaderboardsPage} from './pages/LeaderboardsPage'

class App extends Component {
    render() {
        return (
            <BrowserRouter>
            <div className="app">
                <img src={triangle} className="triangle" />

                <div className="page">
                        <Route exact path="/" component={LandingPage} />
                        <Route path="/rules" component={RulesPage} />
                        <Route path="/leaderboards" component={LeaderboardsPage} />
                </div>
            </div>
            </BrowserRouter>
        );
    }
}

export default App;

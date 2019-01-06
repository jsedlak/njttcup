import React, { Component } from 'react';
import './App.css';
import triangle from './triangle.svg';
import { BrowserRouter, Route } from 'react-router-dom';

import {LandingPage} from './pages/LandingPage'
import {RulesPage} from './pages/RulesPage'

class App extends Component {
    render() {
        return (
            <BrowserRouter>
            <div className="app">
                <img src={triangle} className="triangle" />

                <div className="page">
                        <Route exact path="/" component={LandingPage} />
                        <Route path="/rules" component={RulesPage} />
                </div>
            </div>
            </BrowserRouter>
        );
    }
}

export default App;

import React from 'react';
import { Header, Menu } from '../parts/PageParts';
import './LandingPage.css'
import CastelliLogo from '../svg/castelli-logo.svg'

export class LandingPage extends React.Component {
    render() {
        return (
            <div>
                <Header />
                <div style={{ display: 'flex', justifyContent: 'center' }}>
                    <Menu />
                </div>

                <div style={{position:'relative'}}>
                    <img 
                        alt="man riding time trial bike"
                        src="/images/hero.png" 
                        style={{display: 'block', width: '100%', height: 'auto'}} 
                    />

                    <div className="text-inverse text-center text-large" style={{position:'absolute', right: '30px', top: '30px'}}>
                        <strong style={{textTransform: 'uppercase'}}>GOT WHAT IT TAKES?</strong>
                        <br/>
                        NJ State Championships<br/>
                        40KM Individual Time Trial<br/>
                        9 June 2019<br/>
                        <a className="btn btn-inverse" href="https://www.bikereg.com">Register Now</a>
                    </div>

                    <div className="bg-red" style={{width:'100%', padding: '60px', margin: '0', display: 'flex', justifyContent: 'space-between'}}>
                        <h1 style={{width:'33%', color:'#fff'}}>THANK YOU<br/>TO OUR SPONSORS</h1>
                        <img src={CastelliLogo} alt="Castelli Logo" style={{width: '33%'}} />
                    </div>
                </div>
            </div>
        )
    }
}
import React from 'react';
import { Header, Menu } from '../parts/PageParts';
import './LandingPage.css'
import CastelliLogo from '../svg/castelli-logo.svg'
import NjbaLogo from '../svg/njba-logo.svg'

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
                    
                    <div style={{display:'flex', justifyContent:'center', alignItems: 'center', position: 'absolute', left: 0, top: 0, width: '100%', height: '100%'}}>

                        <div className="text-inverse text-center text-large">
                            <strong style={{textTransform: 'uppercase'}}>GOT WHAT IT TAKES?</strong>
                            <br/>
                            NJ State Championships<br/>
                            <span class="hide-phone">40KM Individual Time Trial<br/></span>
                            5 May 2019<br/>
                            {/* <a className="btn btn-inverse" href="https://www.bikereg.com">Register Now</a> */}
                        </div>
                    </div>
                </div>

                <div className="block-phone bg-red" style={{width:'100%', padding: '60px', margin: '0', display: 'flex', justifyContent: 'space-between'}}>
                        <h1 style={{width:'33%', color:'#fff'}}>THANK YOU<br/>TO OUR SPONSORS</h1>
                        <img src={NjbaLogo} alt="NJBA Logo" style={{width: '33%'}} />
                        <img src={CastelliLogo} alt="Castelli Logo" style={{width: '33%'}} />
                    </div>
            </div>
        )
    }
}
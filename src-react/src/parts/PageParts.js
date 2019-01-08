import React from 'react';
import logo from '../logo.svg';

export class Header extends React.Component {
    render() {
        return (
            <header id="Header">
                <img alt="NJ Time Trial Cup series" src={logo} />
                <div className="br"></div>
                {this.props.children}
            </header>
        )
    }
}

const NavItems = [
    { path: '/', title: 'Home ', exact: true },
    { path: '/schedule', title: 'Schedule' },
    { path: '/courses', title: 'Courses' },
    { path: '/rules', title: 'Rules' },
    { path: '/results', title: 'Results' },
    { path: '/leaderboards', title: 'Leaderboards' }
]

export class Menu extends React.Component {
    render() {
        const getClass = (item) => {
            if(item.exact) {
                if(window.location.pathname.toLowerCase() === item.path.toLowerCase()) {
                    return 'active';
                }

                return '';
            }
            
            if(window.location.pathname.toLowerCase().indexOf(item.path.toLowerCase()) === 0) {
                return 'active';
            }
            return '';
        };

        return (
            <nav id="Menu">
                <ul>
                    {NavItems.map((item, itemIndex) => 
                        <li key={itemIndex} className={getClass(item)}>
                            <a href={item.path}>{item.title}</a>
                        </li>
                    )}
                </ul>
            </nav>
        )
    }
}

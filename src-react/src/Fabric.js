var api = 'https://api.njttcup.com/api/';
//var api = 'http://localhost:7071/api/'
export class Fabric {
    getYears = () => {
        return fetch(api + 'years')
            .then(data => data.json());
    }
    getEvents = (year) => {
        return fetch(api + 'years/' + year + '/events')
            .then(data => data.json());
    }

    getLeaderboard = (year) => {
        return fetch(api + 'years/' + year + '/leaderboard')
            .then(data => data.json());
    }
}
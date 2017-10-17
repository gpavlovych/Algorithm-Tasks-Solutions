import * as React from "react";
import {Header} from "./Header";

export class App extends React.Component {
    render() {
        //TODO:
        // switch routeUrl: '/'->Home if logged in, Welcome if Logged out
        // routeUrl: 'sign-in' => Login window with the Log In tab
        // routeUrl: 'sign-up' => Login window with the Sign Up tab
        return <Header/>;
    }
}
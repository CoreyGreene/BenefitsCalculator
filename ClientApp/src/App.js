import React, { Component } from 'react';
import { Route } from 'react-router';
import { BenefitsCalculatorLayout } from './Pages/BenefitsCalculatorLayout';
import { EmployeeInfo } from './components/EmployeeInfo';

import './custom.css'

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <BenefitsCalculatorLayout>
                <Route exact path='/' component={EmployeeInfo} />
            </BenefitsCalculatorLayout>
        );
    }
}

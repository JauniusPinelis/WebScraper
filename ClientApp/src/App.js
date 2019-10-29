import React, {Component} from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';

import DataTable from './Components/DataTable';

class App extends Component {
  constructor() {
    super();
    this.state = {
     htmlData: []
    };
  }
  render(){
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <p>
            Testing for now
          </p>
          <div>
          <DataTable />
        </div>
        </header>
        
      </div>
    );
  }
  componentDidMount() {
    this.loadData();
  }

  loadData = () => {
    axios
      .get("/api/data/")
      .then(res => {
        this.setState({
          htmlData: res.data
        });
      })
      .catch(error => {});
  };
  
}

export default App;

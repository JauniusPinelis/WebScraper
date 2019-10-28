import React, {Component} from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';

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
            Edit <code>src/App.js</code> and save to reload.
          </p>
          <a
            className="App-link"
            href="https://reactjs.org"
            target="_blank"
            rel="noopener noreferrer"
          >
            Learn React
          </a>
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

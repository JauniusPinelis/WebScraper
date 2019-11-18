import React, { Component } from "react";
import "./App.css";
import axios from "axios";

import DataTable from "./Components/DataTable";
import Container from "@material-ui/core/Container";

class App extends Component {
  constructor() {
    super();
    this.state = {
      data: [],
      urls: []
    };
  }
  render() {
    return (
      <div className="App">
        <Container>
        
          <h2>Jobs</h2>
          <div>
            <DataTable data={this.state.data} />
          </div>
        </Container>
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
          data: res.data.jobUrls,
          urls: res.data.jobUrls.map(d => d.url)
        });
      })
      .catch(error => {});
  };
}

export default App;

import React, { Component } from "react";
import MaterialTable from "material-table";

export default class DataTable extends Component {
  render() {
    return (
      <div style={{ maxWidth: "100%" }}>
        <MaterialTable
          columns={[
            { title: "No", field: "id" },
            { title: "Title", field: "title" },
            { title: "Salary", field: "salary", type: "numeric" },
            { title: "Url", field: "url" },
          ]}
          data={this.props.data}
          title="Demo Title"
        />
      </div>
    );
  }
}

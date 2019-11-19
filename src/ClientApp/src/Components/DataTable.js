import React, { Component } from "react";
import MaterialTable from "material-table";
import { Button } from '@material-ui/core';

export default class DataTable extends Component {
  openUrl = (url) => {
    
  }
  render = () => {
    return (
      <div style={{ maxWidth: "100%" }}>
        <MaterialTable
          columns={[
            { title: "No", field: "id" },
            { title: "Title", field: "title" },
            { title: "Location", field: "location" },
            { title: "Company", field: "company" }
            { title: "Salary", field: "salary"},
            { title: "Apply", apply: "apply",  
            render: rowData => <Button color="primary">Apply</Button>
          }
          ]}
          data={this.props.data}
          title="Jobs"
          actions={[
            /*{
              icon: 'save',
              tooltip: 'Apply',
              onClick: (event, rowData) => {window.open(rowData.url, "_blank")}
            },
            rowData => ({
              icon: 'delete',
              tooltip: 'Delete User',
              onClick: (event, rowData) => this.openUrl("You want to delete " + rowData.name),
              disabled: rowData.birthYear < 2000
            })*/
          ]}
          options={{
            actionsColumnIndex: -1,
            rowStyle: {
              backgroundColor: '#EEE',
            }
          }}
        />
      </div>
    );
  }
}

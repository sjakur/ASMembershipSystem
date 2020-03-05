import React, { Component } from "react"
import { Switch } from "react-router-dom"
import MainLayout from "./components/layout/Main"
import LayoutHOC from "./components/layout/LayoutHOC"
import MemberDetails from "./components/MemberDetails/MemberDetails"
import MemberCreation from "./components/MemberDetails/MemberCreation"
import MemberList from "./components/MemberList/MemberList"
import SportList from "./components/SportList/SportList"

const Routes = () => {
  return (
    <Switch>
      <LayoutHOC component={MemberList} exact layout={MainLayout} path="/" />
      <LayoutHOC
        component={MemberList}
        exact
        layout={MainLayout}
        path="/members"
      />
      <LayoutHOC
        component={SportList}
        exact
        layout={MainLayout}
        path="/sports"
      />
      <LayoutHOC
        component={MemberCreation}
        exact
        layout={MainLayout}
        path="/members/create"
      />
      <LayoutHOC
        component={MemberDetails}
        exact
        layout={MainLayout}
        path="/members/:id"
      />
    </Switch>
  )
}

export default Routes

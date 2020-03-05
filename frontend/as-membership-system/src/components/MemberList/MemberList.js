import React, { useEffect } from "react"
import { useSelector, useDispatch } from "react-redux"

import { makeStyles } from "@material-ui/core/styles"

import MembersTable from "./MembersTable"
import MembersToolbar from "./MembersToolbar"
import Spinner from "../common/Spinner"

import { fetchMembers } from "../../actions/membersActions"

const useStyles = makeStyles(theme => ({
  root: {
    padding: theme.spacing(3)
  },
  content: {
    marginTop: theme.spacing(2)
  }
}))

const MemberList = () => {
  const classes = useStyles()

  const dispatch = useDispatch()

  const members = useSelector(state => state.members, [])

  const isLoading = useSelector(state => state.apiCalls, 0) > 0

  useEffect(() => {
    dispatch(fetchMembers())
  }, [])

  return (
    <div className={classes.root}>
      <MembersToolbar />
      <div className={classes.content}>
        {isLoading ? <Spinner /> : <MembersTable members={members} />}
      </div>
    </div>
  )
}

export default MemberList

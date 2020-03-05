import React, { useEffect } from "react"
import { useSelector, useDispatch } from "react-redux"

import { makeStyles } from "@material-ui/core/styles"

import SportsTable from "./SportsTable"
import Spinner from "../common/Spinner"

import { fetchSports } from "../../actions/sportsActions"

const useStyles = makeStyles(theme => ({
  root: {
    padding: theme.spacing(3)
  },
  content: {
    marginTop: theme.spacing(2)
  }
}))

const SportList = () => {
  const classes = useStyles()

  const dispatch = useDispatch()

  const sports = useSelector(state => state.sports, [])

  const isLoading = useSelector(state => state.apiCalls, 0) > 0

  useEffect(() => {
    dispatch(fetchSports())
  }, [])

  return (
    <div className={classes.root}>
      <div className={classes.content}>
        {isLoading ? <Spinner /> : <SportsTable sports={sports} />}
      </div>
    </div>
  )
}

export default SportList

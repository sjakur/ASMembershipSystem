import React from "react"
import { makeStyles } from "@material-ui/core/styles"
import { Button, Link } from "@material-ui/core"
import { Link as RouterLink } from "react-router-dom"
const useStyles = makeStyles(theme => ({
  row: {
    height: "42px",
    display: "flex",
    alignItems: "center",
    marginTop: theme.spacing(1)
  },
  spacer: {
    flexGrow: 1
  }
}))

const MembersToolbar = () => {
  const classes = useStyles()
  return (
    <div className={classes.row}>
      <span className={classes.spacer} />
      <RouterLink to="/members/create">
        <Button color="primary" variant="contained">
          Add member
        </Button>
      </RouterLink>
    </div>
  )
}

export default MembersToolbar

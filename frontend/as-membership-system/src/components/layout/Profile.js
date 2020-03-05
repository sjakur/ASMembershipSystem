import React from "react"
import { Avatar, Typography } from "@material-ui/core"
import { makeStyles } from "@material-ui/core/styles"

const user = {
  name: "Demo Admin",
  avatar: "SA",
  bio: "System Administrator"
}

const useStyles = makeStyles(theme => ({
  root: {
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
    minHeight: "fit-content"
  },
  avatar: {
    width: 60,
    height: 60
  },
  name: {
    marginTop: theme.spacing(1)
  }
}))

const Profile = () => {
  const classes = useStyles()
  return (
    <div className={classes.root}>
      <Avatar className={classes.avatar}>{user.avatar}</Avatar>
      <Typography className={classes.name} variant="h5">
        {user.name}
      </Typography>
      <Typography variant="body2">{user.bio}</Typography>
    </div>
  )
}

export default Profile

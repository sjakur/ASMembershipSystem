import React from "react"
import PropTypes from "prop-types"
import { Typography, Toolbar, AppBar, IconButton } from "@material-ui/core"
import MenuIcon from "@material-ui/icons/Menu"
import { makeStyles } from "@material-ui/core/styles"

const useStyles = makeStyles(theme => ({
  root: {
    flexGrow: 1,
    boxShadow: "none"
  },
  menuButton: {
    marginRight: theme.spacing(2),
    [theme.breakpoints.up("sm")]: {
      display: "none"
    }
  },
  title: {
    flexGrow: 1
  }
}))

const CustomAppBar = ({ handleSidebarToggle }) => {
  const classes = useStyles()
  return (
    <AppBar className={classes.root} position="fixed">
      <Toolbar>
        <IconButton
          className={classes.menuButton}
          color="inherit"
          onClick={handleSidebarToggle}
        >
          <MenuIcon />
        </IconButton>
        <Typography variant="h6" className={classes.title}>
          Amsterdam Sports Inc.
        </Typography>
      </Toolbar>
    </AppBar>
  )
}

CustomAppBar.propTypes = {
  handleSidebarToggle: PropTypes.func
}

export default CustomAppBar

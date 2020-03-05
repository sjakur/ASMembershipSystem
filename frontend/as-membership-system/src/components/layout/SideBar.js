import React from "react"
import PropTypes from "prop-types"
import PeopleIcon from "@material-ui/icons/People"
import SportsIcon from "@material-ui/icons/Sports"
import Profile from "./Profile"
import {
  Drawer,
  Divider,
  List,
  ListItem,
  ListItemIcon,
  ListItemText
} from "@material-ui/core"
import { makeStyles } from "@material-ui/core/styles"
import { Link } from "react-router-dom"

const useStyles = makeStyles(theme => ({
  drawer: {
    width: 240,
    [theme.breakpoints.up("lg")]: {
      marginTop: 64,
      height: "calc(100% - 64px)",
      flexShrink: 0
    }
  },
  root: {
    backgroundColor: theme.palette.white,
    display: "flex",
    flexDirection: "column",
    height: "100%",
    padding: theme.spacing(2)
  },
  divider: {
    margin: theme.spacing(2, 0)
  },
  listItemIcon: {
    minWidth: 40
  }
}))

const pages = [
  {
    title: "Members",
    href: "/members",
    icon: <PeopleIcon />
  },
  {
    title: "Sports",
    href: "/sports",
    icon: <SportsIcon />
  }
]

const CustomSideBar = ({ open, variant, onClose }) => {
  const classes = useStyles()
  return (
    <Drawer
      anchor="left"
      classes={{
        paper: classes.drawer
      }}
      onClose={onClose}
      open={open}
      variant={variant}
    >
      <div className={classes.root}>
        <Profile />
        <Divider className={classes.divider} />
        <List>
          {pages.map((page, index) => (
            <ListItem key={index} button component={Link} to={page.href}>
              <ListItemIcon className={classes.listItemIcon}>
                {page.icon}
              </ListItemIcon>
              <ListItemText primary={page.title} />
            </ListItem>
          ))}
        </List>
      </div>
    </Drawer>
  )
}

export default CustomSideBar

CustomSideBar.propTypes = {
  open: PropTypes.bool.isRequired,
  onClose: PropTypes.func,
  variant: PropTypes.string.isRequired
}

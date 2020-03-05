import React, { useState } from "react"
import PropTypes from "prop-types"
import AppBar from "./AppBar"
import SideBar from "./SideBar"
import clsx from "clsx"

import { makeStyles } from "@material-ui/core/styles"
import { useTheme } from "@material-ui/core/styles"
import { useMediaQuery } from "@material-ui/core"

const useStyles = makeStyles(theme => ({
  root: {
    paddingTop: 56,
    height: "100%",
    [theme.breakpoints.up("sm")]: {
      paddingTop: 64
    }
  },
  shiftContent: {
    paddingLeft: 240
  },
  content: {
    height: "100%"
  }
}))

const Main = ({ children }) => {
  const classes = useStyles()

  const [openSidebar, setOpenSidebar] = useState(false)

  const handleSidebarToggle = () => {
    setOpenSidebar(!openSidebar)
  }

  const theme = useTheme()

  const isDesktop = useMediaQuery(theme.breakpoints.up("lg"), {
    defaultMatches: true
  })

  const shouldOpenSidebar = isDesktop ? true : openSidebar

  return (
    <div
      className={clsx({
        [classes.root]: true,
        [classes.shiftContent]: isDesktop
      })}
    >
      <AppBar handleSidebarToggle={handleSidebarToggle} />
      <SideBar
        onClose={handleSidebarToggle}
        open={shouldOpenSidebar}
        variant={isDesktop ? "persistent" : "temporary"}
      />
      <main className={classes.content}>{children}</main>
    </div>
  )
}

export default Main

Main.propTypes = {
  children: PropTypes.node
}

import React, { useState } from "react"
import PropTypes from "prop-types"
import { Link as RouterLink } from "react-router-dom"
import {} from "react-router-dom"
import { makeStyles } from "@material-ui/core/styles"
import {
  Card,
  CardActions,
  CardContent,
  Avatar,
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableRow,
  Typography,
  TablePagination,
  Link
} from "@material-ui/core"

import SportsHandballIcon from "@material-ui/icons/SportsHandball"
import SportsSoccerIcon from "@material-ui/icons/SportsSoccer"
import SportsTennisIcon from "@material-ui/icons/SportsTennis"

const useStyles = makeStyles(theme => ({
  root: {},
  content: {
    padding: 0
  },
  inner: {
    minWidth: 1050
  },
  nameContainer: {
    display: "flex",
    alignItems: "center"
  },
  avatar: {
    marginRight: theme.spacing(2)
  },
  actions: {
    justifyContent: "flex-end"
  }
}))

const SportsTable = ({ sports }) => {
  const classes = useStyles()

  const [rowsPerPage, setRowsPerPage] = useState(10)
  const [page, setPage] = useState(0)

  const handlePageChange = (event, page) => {
    setPage(page)
  }

  const handleRowsPerPageChange = event => {
    setRowsPerPage(event.target.value)
  }

  return (
    <Card className={classes.root}>
      <CardContent className={classes.content}>
        <div className={classes.inner}>
          <Table>
            <TableHead>
              <TableRow>
                <TableCell>Name</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {sports.slice(0, rowsPerPage).map(sport => (
                <TableRow className={classes.tableRow} hover key={sport.id}>
                  <TableCell>
                    <div className={classes.nameContainer}>
                      <Avatar className={classes.avatar}>
                        {sport.name == "Squash" && <SportsHandballIcon />}
                        {sport.name == "Tennis" && <SportsTennisIcon />}
                        {sport.name == "Football" && <SportsSoccerIcon />}
                      </Avatar>
                      <Typography variant="body1" color="inherit">
                        {sport.name}
                      </Typography>
                    </div>
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </div>
      </CardContent>
      <CardActions className={classes.actions}>
        <TablePagination
          component="div"
          count={sports.length}
          onChangePage={handlePageChange}
          onChangeRowsPerPage={handleRowsPerPageChange}
          page={page}
          rowsPerPage={rowsPerPage}
          rowsPerPageOptions={[5, 10, 25]}
        />
      </CardActions>
    </Card>
  )
}

export default SportsTable

SportsTable.propTypes = {
  sports: PropTypes.arrayOf(
    PropTypes.shape({
      id: PropTypes.number.isRequired,
      name: PropTypes.string.isRequired
    })
  )
}

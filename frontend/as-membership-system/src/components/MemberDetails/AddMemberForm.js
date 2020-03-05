import React, { useState } from "react"
import PropTypes from "prop-types"

import { useDispatch } from "react-redux"
import { useHistory } from "react-router-dom"

import {
  Grid,
  TextField,
  CardContent,
  CardActions,
  Divider,
  Button
} from "@material-ui/core"
import Autocomplete from "@material-ui/lab/Autocomplete"
import { addNewMember } from "../../actions/memberDetailsActions"

const AddMemberForm = props => {
  const dispatch = useDispatch()
  const history = useHistory()

  const [member, setMember] = useState({
    firstName: "",
    lastName: "",
    sports: []
  })

  const handleSubmit = event => {
    event.preventDefault()
    dispatch(addNewMember(member))
    history.push("/members")
  }

  return (
    <form autoComplete="on">
      <CardContent>
        <Grid container spacing={3}>
          <Grid item md={6} xs={12}>
            <TextField
              fullWidth
              label="First name"
              margin="dense"
              name="firstName"
              onChange={event => {
                setMember({
                  ...member,
                  [event.target.name]: event.target.value
                })
              }}
              required
              value={member.firstName}
              variant="outlined"
            />
          </Grid>
          <Grid item md={6} xs={12}>
            <TextField
              fullWidth
              label="Last name"
              margin="dense"
              name="lastName"
              onChange={event => {
                setMember({
                  ...member,
                  [event.target.name]: event.target.value
                })
              }}
              required
              value={member.lastName}
              variant="outlined"
            />
          </Grid>
          <Grid item md={6} xs={12}>
            <Autocomplete
              multiple
              id="tags-outlined"
              options={props.sports}
              value={props.sports.filter(sport =>
                member.sports.map(s => s.id).includes(sport.id)
              )}
              getOptionLabel={option => option.name}
              onChange={(event, values) => {
                setMember({
                  ...member,
                  sports: values
                })
              }}
              filterSelectedOptions
              renderInput={params => (
                <TextField
                  {...params}
                  fullWidth
                  label="Sports"
                  margin="dense"
                  variant="outlined"
                />
              )}
            />
          </Grid>
        </Grid>
      </CardContent>
      <Divider />
      <CardActions>
        <Button onClick={handleSubmit} color="primary" variant="contained">
          Add member
        </Button>
      </CardActions>
    </form>
  )
}

export default AddMemberForm

AddMemberForm.propTypes = {
  sports: PropTypes.arrayOf(
    PropTypes.shape({
      id: PropTypes.number.isRequired,
      name: PropTypes.string.isRequired
    })
  )
}

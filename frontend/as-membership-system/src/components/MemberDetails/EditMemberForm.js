import React, { useState } from "react"
import { useDispatch } from "react-redux"
import PropTypes from "prop-types"
import {
  Grid,
  TextField,
  CardContent,
  CardActions,
  Divider,
  Button
} from "@material-ui/core"
import Autocomplete from "@material-ui/lab/Autocomplete"
import { updateMemberDetails } from "../../actions/memberDetailsActions"

const EditMemberForm = props => {
  const [member, setMember] = useState(props.member)
  const dispatch = useDispatch()

  const handleSubmit = event => {
    event.preventDefault()
    dispatch(updateMemberDetails(member.id, member))
  }

  return (
    <form onSubmit={handleSubmit}>
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
        <Button type="submit" color="primary" variant="contained">
          Save details
        </Button>
      </CardActions>
    </form>
  )
}

export default EditMemberForm

EditMemberForm.propTypes = {
  sports: PropTypes.arrayOf(
    PropTypes.shape({
      id: PropTypes.number.isRequired,
      name: PropTypes.string.isRequired
    })
  ),
  member: PropTypes.shape({
    id: PropTypes.number.isRequired,
    firstName: PropTypes.string.isRequired,
    lastName: PropTypes.string.isRequired,
    sports: PropTypes.arrayOf(
      PropTypes.shape({
        id: PropTypes.number.isRequired,
        name: PropTypes.string.isRequired
      })
    )
  })
}

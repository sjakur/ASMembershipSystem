import React, { useEffect } from "react"
import PropTypes from "prop-types"
import { useSelector, useDispatch } from "react-redux"

import { Card, CardHeader } from "@material-ui/core"
import Spinner from "../common/Spinner"
import EditMemberForm from "./EditMemberForm"
import { fetchMemberDetails } from "../../actions/memberDetailsActions"
import { fetchSports } from "../../actions/sportsActions"

const MemberDetails = props => {
  const dispatch = useDispatch()

  const member = useSelector(state => state.member, {})

  const sports = useSelector(state => state.sports, [])

  const isLoading = useSelector(state => state.apiCalls, 0) > 0
  useEffect(() => {
    dispatch(fetchMemberDetails(props.match.params.id))
    dispatch(fetchSports())
  }, [])

  return isLoading ? (
    <Spinner />
  ) : (
    <Card>
      <CardHeader
        title="Member profile"
        subheader="The information can be edited"
      />
      <EditMemberForm member={member} sports={sports} />
    </Card>
  )
}

export default MemberDetails

MemberDetails.propTypes = {
  match: PropTypes.shape({
    params: PropTypes.shape({
      id: PropTypes.string.isRequired
    })
  })
}

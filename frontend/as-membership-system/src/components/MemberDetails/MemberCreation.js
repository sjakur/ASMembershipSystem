import React, { useEffect } from "react"
import { useSelector, useDispatch } from "react-redux"

import { Card, CardHeader } from "@material-ui/core"
import Spinner from "../common/Spinner"
import AddMemberForm from "./AddMemberForm"
import { fetchSports } from "../../actions/sportsActions"

const MemberCreation = () => {
  const dispatch = useDispatch()

  const sports = useSelector(state => state.sports, [])

  const isLoading = useSelector(state => state.apiCalls, 0) > 0

  useEffect(() => {
    dispatch(fetchSports())
  }, [])

  return isLoading ? (
    <Spinner />
  ) : (
    <Card>
      <CardHeader
        title="New Member"
        subheader="Please fill in the required fields"
      />
      <AddMemberForm sports={sports} />
    </Card>
  )
}

export default MemberCreation

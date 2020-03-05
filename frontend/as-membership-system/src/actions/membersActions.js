import axios from "../axios"
import * as actionTypes from "./actionTypes"
import { apiCallStarted, ApiCallFailed } from "./apiStatusActions"

export const fetchMembersSuccess = data => {
  return {
    type: actionTypes.FETCH_MEMBERS_SUCCESS,
    data
  }
}

export const fetchMembers = () => {
  return dispatch => {
    dispatch(apiCallStarted())
    return axios
      .get("/members")
      .then(response => {
        dispatch(fetchMembersSuccess(response.data))
      })
      .catch(error => {
        dispatch(ApiCallFailed())
        throw error
      })
  }
}

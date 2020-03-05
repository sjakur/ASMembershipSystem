import axios from "../axios"
import * as actionTypes from "./actionTypes"
import { apiCallStarted, ApiCallFailed } from "./apiStatusActions"

export const fetchMemberDetailsSuccess = data => {
  return {
    type: actionTypes.FETCH_MEMBER_DETAILS_SUCCESS,
    data
  }
}

export const fetchMemberDetails = id => {
  return dispatch => {
    dispatch(apiCallStarted())
    return axios
      .get(`/members/${id}`)
      .then(response => {
        dispatch(fetchMemberDetailsSuccess(response.data))
      })
      .catch(error => {
        dispatch(ApiCallFailed())
        throw error
      })
  }
}

export const updateMemberDetailsSuccess = data => {
  return {
    type: actionTypes.UPDATE_MEMBER_DETAILS_SUCCESS,
    data
  }
}

export const updateMemberDetails = (id, member) => {
  return dispatch => {
    dispatch(apiCallStarted())
    return axios
      .put(`/members/${id}`, member)
      .then(() => {
        dispatch(updateMemberDetailsSuccess(member))
      })
      .catch(error => {
        dispatch(ApiCallFailed())
        throw error
      })
  }
}

export const createNewMemberSuccess = data => {
  return {
    type: actionTypes.CREATE_MEMBER_SUCCESS,
    data
  }
}

export const addNewMember = member => {
  return dispatch => {
    dispatch(apiCallStarted())
    return axios
      .post("/members", member)
      .then(response => {
        dispatch(createNewMemberSuccess(response.data))
      })
      .catch(error => {
        dispatch(ApiCallFailed())
        throw error
      })
  }
}

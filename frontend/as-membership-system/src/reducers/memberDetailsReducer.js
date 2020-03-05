import * as actionTypes from "../actions/actionTypes"
import initialState from "./initialState"

const membersReducer = (state = initialState.member, action) => {
  switch (action.type) {
    case actionTypes.FETCH_MEMBER_DETAILS_SUCCESS:
      return action.data
    case actionTypes.UPDATE_MEMBER_DETAILS_SUCCESS:
      return action.data
    default:
      return state
  }
}

export default membersReducer

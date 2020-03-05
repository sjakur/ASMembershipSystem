import * as actionTypes from "../actions/actionTypes"
import initialState from "./initialState"

const membersReducer = (state = initialState.members, action) => {
  switch (action.type) {
    case actionTypes.FETCH_MEMBERS_SUCCESS:
      return action.data
    case actionTypes.CREATE_MEMBER_SUCCESS:
      return [...state, action.data]
    default:
      return state
  }
}

export default membersReducer

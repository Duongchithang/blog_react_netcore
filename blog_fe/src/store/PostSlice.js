import { createSlice } from "@reduxjs/toolkit";
const PostSlice = createSlice({
    name : "post",
   initialState : {
    html : ""
   },
   reducers : {
      passDataHtml(state, action){
        state.html = action.payload;
      }
   },

});
export default PostSlice.reducer;
export const { passDataHtml } = PostSlice.actions;
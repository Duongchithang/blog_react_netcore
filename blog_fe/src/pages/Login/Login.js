import { Button, Checkbox, FormControlLabel, TextField } from "@mui/material";
import axios from "axios";
import { URL_BACKEND } from "../../constant";
import { useState } from "react";
import { toast, ToastContainer } from "react-toastify";
import { styled } from "@mui/material/styles";
import "./Login.css";
import { Link } from "react-router-dom";

function Login() {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const notify = () =>
    toast("🦄 Testing feature", {
      position: "top-right",
      autoClose: 5000,
      hideProgressBar: false,
      closeOnClick: true,
      pauseOnHover: true,
      draggable: true,
      progress: undefined,
      theme: "light",
    });
  const HandleLogin = async () => {
    notify();
    // const response = await axios.post(`http://localhost:5156/api/login`, { username, password });
    // if ((response.data.message = "success")) {
    //   notify();
    // }
  };

  return (
    <div className="container container-login">
      <div className="row justify-content-center mt-5">
        <div className="col-5 form-login">
          <h1 className="text-center head-form">Login</h1>
          <div className="row">
            <TextField
              className="col-12 mt-3"
              onChange={(e) => {
                setUsername(e.target.value);
              }}
              id="outlined-basic"
              label="Username"
              variant="outlined"
            />
            <TextField
              className="col-12 mt-3"
              onChange={(e) => {
                setPassword(e.target.value);
              }}
              id="outlined-basic"
              label="Password"
              variant="outlined"
            />
            <div className="col-12 p-0">
              <div className="row justify-content-between align-items-center">
                <FormControlLabel
                  className="col-5 check-box"
                  control={<Checkbox />}
                  label="Remember me"
                />
                <Link className="col-5 forgot-password">Forgot my password ?</Link>
              </div>
            </div>
            <Button onClick={HandleLogin} className="col-12 mt-3 py-2" variant="contained">
              Submit
            </Button>
          </div>
          <ToastContainer />
        </div>
      </div>
    </div>
  );
}

export default Login;

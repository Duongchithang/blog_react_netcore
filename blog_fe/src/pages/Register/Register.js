import { Button, TextField } from "@mui/material";
import { Link } from "react-router-dom";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import axios from "axios";
import * as yup from "yup";
import { URL_BACKEND } from "../../constant";
import "./Register.css";
import { toast, ToastContainer } from "react-toastify";

function Register() {
  const notify = (message) =>
    toast(`🦄 ${message} !`, {
      position: "top-right",
      autoClose: 5000,
      hideProgressBar: false,
      closeOnClick: true,
      pauseOnHover: true,
      draggable: true,
      progress: undefined,
      theme: "light",
    });
  const schema = yup
    .object({
      username: yup.string().trim("Tài khoản không có khoảng trắng !").required("Không được để trống").min(6 ,"Tài khoản có độ dài lớn hơn 6").max(16,"Tài khoản có đọ dài bé hơn 16"),
      password: yup.string().trim("Mật khẩu không có khoảng trắng !").required("Không được để trống").min(6, "Mật khẩu có độ dài lớn hơn 6 !").max(16,"Mật khẩu có độ dài bé hơn 16"),
      confirmPassword : yup.string().required("Không được để trống").oneOf([yup.ref('password')], 'Mật khẩu không khớp')
    });
  
  // valdate input
  const {
    register,
    handleSubmit,
    watch,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
  });
  const onSubmit = async (data) => {
    if(Object.keys(errors).length === 0){
      const createAccount = {
        username : data.username,
        password : data.password
      }
     const response = await HandleSignUp(createAccount);
     if(response.data.statusCode === 400){
      notify("Người dùng đã được đăng kí");
     };
     if(response.data.statusCode === 200){
      notify("Đăng kí thành công");
     }
    } 

  };
  const HandleSignUp = async (infoUser) =>{
    return axios.post(`${URL_BACKEND}/api/Register`, infoUser);
  }
   
  return (
    <div className="mt-5">
      <div className="row justify-content-center">
        <div className="container-register col-5">
          <h1 className="title-register">Create your account</h1>
          <form onSubmit={handleSubmit(onSubmit)}>
            <TextField
              style={{ marginTop: "15px" }}
              {...register("username", { required: true, minLength: 6 })}
              error={errors.username ? true : false}
              className="col-12"
              id="standard-basic"
              label="Username"
              variant="standard"
              helperText={errors.username ? errors.username.message : null}
            />

            <TextField
              style={{ marginTop: "15px" }}
              {...register("password", { required: true })}
               error={errors.password ? true : false}
              className="col-12"
              id="standard-basic"
              label="Password"
              variant="standard"
               helperText={errors.password ? errors.password.message : null}
            />
              
               <TextField
              style={{ marginTop: "15px" }}
              {...register("confirmPassword", { required: true })}
              error={errors.confirmPassword ? true : false}
              className="col-12"
              id="standard-basic"
              label="ConfirmPassword"
              variant="standard"
              helperText={errors.confirmPassword ? errors.confirmPassword.message : null}
            />
            <Button
              type="submit"
              style={{ marginTop: "20px", fontSize: "18px" }}
              variant="contained"
            >
              Create account
            </Button>
          </form>
          <div className="register-back">
            <Link to={"/login"}>Already have an account? Sign in</Link>
          </div>
            <ToastContainer />
        </div>
      </div>

    </div>
  );
}

export default Register;

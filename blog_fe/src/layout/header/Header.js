import { useEffect, useState } from "react";
import { Link, NavLink } from "react-router-dom";
import "./Header.css";
function Header() {
  console.log(">>> Header Mount");
  return (
   <div className="container-header">
     <div className="container">
      <div className="container-navbar">
        <div className="navbar navbar-expand-lg ">
          <Link to={"/"}  className="navbar-brand logo">
            CHITHANGDEVBLOG
          </Link>
          <button
            className="navbar-toggler"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target="#navbarNav"
            aria-controls="navbarNav"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse row justify-content-lg-end" id="navbarNav">
            <div className="col-sm-12 col-lg-6">
              <ul className="list-item row text-sm-left text-lg-center align-items-center">
                <li className="nav-item menu-item col-sm-6 col-lg-3">
                  <a className="nav-link active" aria-current="page" href="#">
                    Home
                  </a>
                </li>
                <li className="nav-item menu-item col-sm-6 col-lg-3">
                  <a className="nav-link" href="#">
                    Articles
                  </a>
                </li>
                <li
                  className="nav-item dropdown menu-item d-flex align-items-center col-sm-6 col-lg-3"
                  data-bs-toggle="dropdown"
                  aria-expanded="false"
                >
                  <a className="nav-link " type="button" data-bs-toggle="dropdown" aria-expanded="false">
                    Page
                  </a>
                  <box-icon color="white" name="chevron-down"></box-icon>
                  {/* <ul class="dropdown-menu">
                    <li>
                      <a class="dropdown-item" href="#">
                        Action
                      </a>
                    </li>
                    <li>
                      <a class="dropdown-item" href="#">
                        Another action
                      </a>
                    </li>
                    <li>
                      <a class="dropdown-item" href="#">
                        Something else here
                      </a>
                    </li>
                  </ul> */}
                </li>
                <li className="nav-item menu-item col-sm-6 col-lg-3">
                  <Link to="/login" className="nav-link btn-signin">Sign In</Link>
                </li>
              </ul>
            </div>
          </div>
        </div>
      </div>
    </div>
   </div>
  );
}
export default Header;

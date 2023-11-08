import { Outlet, Link } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faNewspaper,
  faVial,
  faUsers,
  faHome,
  faInfoCircle,
  faShieldAlt,
  faUser,
  faBook,
} from "@fortawesome/free-solid-svg-icons";
import "./Layout.css";

const Layout = () => {
  return (
    <div className="container-fluid px-0">
      <nav className="navbar navbar-expand-md navbar-dark bg-primary">
        <div className="container-fluid">
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
          <Link className="nav-link d-md-none" to="/">
            <FontAwesomeIcon icon={faHome} className="fa-home-icon" />
          </Link>
          <Link className="nav-link d-md-none" to="/user">
            <FontAwesomeIcon icon={faUser} className="fa-user-icon" />
          </Link>
          <div className="collapse navbar-collapse" id="navbarNav">
            <ul className="navbar-nav ml-auto">
              <li className="nav-item">
                <Link className="nav-link d-none d-md-block" to="/articles">
                  Articles
                </Link>
                <Link
                  className="nav-link d-md-none d-flex justify-content-center align-items-center"
                  to="/articles"
                >
                  <FontAwesomeIcon icon={faNewspaper} />
                </Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link d-none d-md-block" to="/tests">
                  Tests
                </Link>
                <Link
                  className="nav-link d-md-none d-flex justify-content-center align-items-center"
                  to="/tests"
                >
                  <FontAwesomeIcon icon={faVial} />
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link d-none d-md-block"
                  to="/consultations"
                >
                  Consultations
                </Link>
                <Link
                  className="nav-link d-md-none d-flex justify-content-center align-items-center"
                  to="/consultations"
                >
                  <FontAwesomeIcon icon={faUsers} />
                </Link>
              </li>
            </ul>
            <Link className="navbar-brand mx-auto d-none d-md-block" to="/">
              Wellbeing of Mind
            </Link>
            <ul className="navbar-nav">
              <li className="nav-item">
                <Link className="nav-link d-none d-md-block" to="/about">
                  About
                </Link>
                <Link
                  className="nav-link d-md-none d-flex justify-content-center align-items-center"
                  to="/about"
                >
                  <FontAwesomeIcon icon={faInfoCircle} />
                </Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link d-none d-md-block" to="/privacy">
                  Privacy Policy
                </Link>
                <Link
                  className="nav-link d-md-none d-flex justify-content-center align-items-center"
                  to="/privacy"
                >
                  <FontAwesomeIcon icon={faShieldAlt} />
                </Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link d-none d-md-block" to="/journey">
                  Journey
                </Link>
                <Link
                  className="nav-link d-md-none d-flex justify-content-center align-items-center"
                  to="/privacy"
                >
                  <FontAwesomeIcon icon={faBook} />
                </Link>
              </li>
            </ul>
          </div>
        </div>
      </nav>
      <Outlet />
    </div>
  );
};

export default Layout;

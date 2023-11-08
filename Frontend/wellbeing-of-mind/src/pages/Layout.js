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
} from "@fortawesome/free-solid-svg-icons";
import "./Layout.css";

const Layout = () => {
  return (
    <div className="container">
      <nav className="navbar navbar-expand-lg navbar-light bg-light">
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
          <span className="nav-item d-lg-none">
            <Link className="nav-link d-flex justify-content-center" to="/">
              <FontAwesomeIcon icon={faHome} className="fa-home-icon" />
            </Link>
          </span>
          <span className="nav-item d-lg-none">
            <Link className="nav-link d-flex justify-content-center" to="/user">
              <FontAwesomeIcon icon={faUser} className="fa-user-icon" />
            </Link>
          </span>
          <div className="collapse navbar-collapse" id="navbarNav">
            <ul className="navbar-nav ml-auto">
              <li className="nav-item">
                <Link className="nav-link d-none d-lg-block" to="/articles">
                  Articles
                </Link>
                <Link
                  className="nav-link d-lg-none d-flex justify-content-center align-items-center"
                  to="/articles"
                >
                  <FontAwesomeIcon icon={faNewspaper} />
                </Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link d-none d-lg-block" to="/tests">
                  Tests
                </Link>
                <Link
                  className="nav-link d-lg-none d-flex justify-content-center align-items-center"
                  to="/tests"
                >
                  <FontAwesomeIcon icon={faVial} />
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link d-none d-lg-block"
                  to="/consultations"
                >
                  Consultations
                </Link>
                <Link
                  className="nav-link d-lg-none d-flex justify-content-center align-items-center"
                  to="/consultations"
                >
                  <FontAwesomeIcon icon={faUsers} />
                </Link>
              </li>
            </ul>
            <Link className="navbar-brand mx-auto d-none d-lg-block" to="/">
              Wellbeing of Mind
            </Link>
            <ul className="navbar-nav">
              <li className="nav-item">
                <Link className="nav-link d-none d-lg-block" to="/about">
                  About
                </Link>
                <Link
                  className="nav-link d-lg-none d-flex justify-content-center align-items-center"
                  to="/about"
                >
                  <FontAwesomeIcon icon={faInfoCircle} />
                </Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link d-none d-lg-block" to="/privacy">
                  Privacy Policy
                </Link>
                <Link
                  className="nav-link d-lg-none d-flex justify-content-center align-items-center"
                  to="/privacy"
                >
                  <FontAwesomeIcon icon={faShieldAlt} />
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

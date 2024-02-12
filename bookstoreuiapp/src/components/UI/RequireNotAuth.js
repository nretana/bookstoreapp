import { useSelector } from "react-redux";
import { Navigate } from "react-router-dom";

const RequireNotAuth = (props) => {

    const isSignedIn = useSelector(state => state.authState.isSignedIn);

    return(!isSignedIn ? props.children : <Navigate to="/" replace />);
}

export default RequireNotAuth;
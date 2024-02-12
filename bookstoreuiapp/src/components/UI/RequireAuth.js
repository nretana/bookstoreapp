import { useSelector } from "react-redux";

import ForbiddenPage from "../../pages/ForbiddenPage";

const RequireAuth = (props) => {
    
    const isSignedIn = useSelector(state => state.authState.isSignedIn);
    
    return(isSignedIn ? props.children : <ForbiddenPage />)
}

export default RequireAuth;
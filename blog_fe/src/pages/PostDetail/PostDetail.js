import { useSelector } from "react-redux";

function PostDetail() {
    const selector = useSelector(state => state.Post.html);
    console.log(selector);  
    return ( 
        <div>
            <div style={{color : "white"}}   dangerouslySetInnerHTML={{ __html : selector }}></div>
        </div>
     );
}

export default PostDetail;
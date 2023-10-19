import React from "react";
import Header from "./Header"
import Footer from "./Footer"
import FilterableQuestionWrapper from "./FilterableQuestionWrapper"
import Container from "react-bootstrap/Container"

export default class Layout extends React.Component {
        
        
    
    render() {
    
        return (
            <Container>
                <Header />
                <FilterableQuestionWrapper />
                <Footer />
            </Container>

        )
    }
}
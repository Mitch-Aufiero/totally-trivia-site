import React from "react";
import Question from "./Question"
import CategorySelector from "./CategorySelector"

export default class FilterableQuesitonWrapper extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
          category: ''
        };
          
    this.handleCategoryChange = this.handleCategoryChange.bind(this);
    }
        
    handleCategoryChange(category) {
        this.setState({
            category: category
        });
      }
    
    render() {
    
        return (
            <div>
                <CategorySelector 
                filterCategory={this.state.category}
                onFilterCategoryChange={this.handleCategoryChange}/>
                <Question 
                filterCategory={this.state.category}/>
            </div>

        )
    }
}
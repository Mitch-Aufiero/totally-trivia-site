import React from "react";
import '../style/Question.css';
import Button from "react-bootstrap/Button"
import InputGroup from "react-bootstrap/InputGroup"
import Form from "react-bootstrap/Form"
import FormControl from "react-bootstrap/FormControl"
import ButtonGroup from "react-bootstrap/ButtonGroup"




export default class CategorySelector extends React.Component {
    constructor(props) {
        super(props);
        this.handleCategoryChange = this.handleCategoryChange.bind(this);
        this.state={
            loading: true
        }
      }
      
      handleCategoryChange(e) {
        this.props.onFilterCategoryChange(e.target.value);
      }

    async componentDidMount()
    {
        const url = "https://totally-trivia.com/api/category"; // move to .env file or config?
        const response = await fetch(url);
        const data = await response.json();
        this.setState({categories:data,loading:false});
        console.log(data);
    }
    render() {
        return (
           
            <div>{this.state.loading ? (
            <div> loading... </div>)
                :(<div> <span>Select a Category: </span>
                        <select 
                        className="categorySelector"
                        onChange={this.handleCategoryChange}>
                            {this.state.categories.map((elem) =>
                                    <option value ={elem.triviaCategory} >
                                        {elem.triviaCategory}
                                    </option>
                                    
                            )}
                        </select>
                    </div>
                )}
            </div>              


        )
    }
}
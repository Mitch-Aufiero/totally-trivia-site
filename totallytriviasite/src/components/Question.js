import React from "react";
import '../style/Question.css';
import Button from "react-bootstrap/Button"
import InputGroup from "react-bootstrap/InputGroup"
import Form from "react-bootstrap/Form"
import FormControl from "react-bootstrap/FormControl"
import ButtonGroup from "react-bootstrap/ButtonGroup"




export default class Question extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            loading: true,
            selectedAnswer: '',
            question: 'What is your favorite color?',
            answers: [
                    'Green',
                    'Blue',
                    'Yellow',
                    'Purple'
            ],
            correctAnswer: '',
            category:''
        }
        
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);

    }

    handleChange(event) {
        this.setState({
            selectedAnswer : event.target.value
        });
    }

    handleSubmit(event){
        event.preventDefault();
        if(this.state.selectedAnswer.includes(this.state.correctAnswer)) alert('You chose the right answer!');
        else alert('You chose the wrong answers!');
        alert(`You chose: ${this.state.selectedAnswer}`);
    }

    async fetchQuestion(cat){
        const url = "https://cors-anywhere.herokuapp.com/https://totally-trivia.com/api/questions";
        const response = await fetch(url.concat("?QuestionCategory=",cat));
        const data = await response.json();
        this.setState({question:data.triviaQuestion, answers:data.wrongAnswers, correctAnswer:data.rightAnswer,loading: false});
        
        console.log(data);
    }

    componentDidMount()
    {
        this.fetchQuestion("General Knowledge");
    }
    componentDidUpdate(prevProps) {
        // Typical usage (don't forget to compare props):
        if (this.props.filterCategory !== prevProps.filterCategory) {
            this.setState({category:this.props.filterCategory})
          this.fetchQuestion(this.props.filterCategory);
        }
        console.log(this.props.filterCategory);
      }
    render() {
        
        return (
           
            <div>{this.state.loading ? (
            <div> loading... </div>)
                :(
                <Form className="questionWrapper" onSubmit={this.handleSubmit}>

                    <Form.Label>{this.state.question}</Form.Label>

                    <div>
                        {this.state.answers.map((answers) =>
                            <InputGroup className="radio">
                                <InputGroup.Radio 
                                    value ={answers} 
                                    checked={this.state.selectedAnswer === answers}
                                    onChange={this.handleChange}
                                ></InputGroup.Radio>
                                <InputGroup.Append>{answers} </InputGroup.Append>
                            </InputGroup>
                        )}
                    </div>
                    
                    <Button className="qBtn" variant="primary" type="submit" size="lg" block>Submit</Button>
            
                    
                </Form>
                )}
            </div>              


        )
    }
}
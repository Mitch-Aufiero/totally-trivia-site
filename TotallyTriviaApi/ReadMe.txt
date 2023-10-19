TotallyTriviaApi is a RESTful api that provides consuming applications access to the trivia DB. 

Current API calls:

    questions:get(category) - returns a random trivia question object pulled from trivia db. If a category is specified it will pull a question from that category.


TODO:


	users:get(userID, app) - returns a user object pulled from trivia db. Must pass in the users id and what application[discord or twitch]
    questions:post(object) - creates a new user into trivia db.
    questions:addscore(id, app, scoreToAdd) - Adds "scoreToAdd" to the users current score.

    questions:post(object) - creates a trivia question into trivia db.
    questions:put(id) - updates a trivia question object in trivia db.

  
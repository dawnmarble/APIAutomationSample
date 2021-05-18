Feature: Getting Comments
  In order to make sure I can interact with Posts via the JSONPlaceholder API
 As a consumer of this API
 I want to be sure I am able to receive Comments on a Post

Scenario: Can get all comments for a post
	When I execute a 'GET' Post where PostId is 1/comments
	Then the response should be a 200 ("OK") response
	And the response body should not be empty

	Scenario: Can filter all comments for a post
	Given I call 'GET' Post where <paramater> is <value>
	Then the response should be a 200 ("OK") response
	And the response body should not be empty

	Examples: 
	| parameter | value              |
	| postId    | 1                  |
	| email     | Eliseo@gardner.biz |
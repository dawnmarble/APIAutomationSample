﻿Feature: Post Posts
 In order to make sure I can interact with Posts via the JSONPlaceholder API
 As a consumer of this API
 I want to be sure I am able to receive the correct response when I send request

@Smoke-HappyPath
Scenario: Can post valid post
	Given a Happy Path Post.json request body
	When I POST the request
	Then the response should be a 201 ("Created") response
	And the response body should be what I expect


Scenario: Can post empty post
#This is failing because its returning a 201 - Intentional fail
	Given a Empty Request Post.json request body
	When I POST the request
	Then the response should be a 400 ("Bad Request") response
	
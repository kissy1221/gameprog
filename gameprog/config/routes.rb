Rails.application.routes.draw do
  # Define your application routes per the DSL in https://guides.rubyonrails.org/routing.html

  get '/code' => "users#code"
  root "users#code"
  # Defines the root path route ("/")
  # root "articles#index"
end

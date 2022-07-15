# Load the Rails application.
require_relative "application"

# Initialize the Rails application.
Rails.application.initialize!

#デフォルトでfalseとなっている以下の箇所をtrueに変更
config.assets.compile = true

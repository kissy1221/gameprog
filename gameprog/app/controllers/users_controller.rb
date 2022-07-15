class UsersController < ApplicationController
    def code
        render action: :code
    end

    def top
        render action: :top
    end
end

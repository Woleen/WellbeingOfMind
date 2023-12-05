import React from 'react';
import PropTypes from 'prop-types';
import { TransitionGroup } from 'react-transition-group';

function Result(props) {
  return (
    <TransitionGroup
      classname="container result"
      component="div"
      transitionname="fade"
      transitionentertimeout={800}
      transitionleavetimeout={500}

      transitionappeartimeout={500}
    >
      <div>
        You have <strong>{props.quizResult}</strong>
      </div>
    </TransitionGroup>
  );
}

Result.propTypes = {
  quizResult: PropTypes.string.isRequired
};

export default Result;